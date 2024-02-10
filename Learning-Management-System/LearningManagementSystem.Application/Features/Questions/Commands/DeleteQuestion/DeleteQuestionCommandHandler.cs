
using LearningManagementSystem.Application.Contracts.Interfaces;
using LearningManagementSystem.Application.Persistence.Courses;
using MediatR;

namespace LearningManagementSystem.Application.Features.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, DeleteQuestionCommandResponse>
    {
        private readonly IQuestionRepository questionRepository;
        private readonly ICourseRepository courseRepository;
        private readonly ICurrentUserService userService;

        public DeleteQuestionCommandHandler(IQuestionRepository questionRepository, ICourseRepository courseRepository, ICurrentUserService userService)
        {
            this.questionRepository = questionRepository;
            this.courseRepository = courseRepository;
            this.userService = userService;
        }

        public async Task<DeleteQuestionCommandResponse> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteQuestionCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new DeleteQuestionCommandResponse
                {
                    Success = false,
                    ValidationsErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var question = await questionRepository.FindByIdAsync(request.QuestionId);
            
            if (!question.IsSuccess)
            {
                return new DeleteQuestionCommandResponse
                {
                    Success = false,
                    ValidationsErrors = new List<string> { question.Error }
                };
            }

            if (!userService.IsUserAdmin())
            {
                var course = await courseRepository.FindByIdAsync(question.Value.Chapter.CourseId);

                if (!course.IsSuccess)
                {
                    return new DeleteQuestionCommandResponse
                    {
                        Success = false,
                        ValidationsErrors = new List<string> { course.Error }
                    };
                }

                var userId = Guid.Parse(userService.UserId);

                if (course.Value.ProfessorId != userId)
                {
                    return new DeleteQuestionCommandResponse
                    {
                        Success = false,
                        ValidationsErrors = ["User doesn't own the course"]
                    };
                }
            }

            await questionRepository.DeleteAsync(request.QuestionId);

            return new DeleteQuestionCommandResponse
            {
                Success = true
            };
        }
    }
}
