namespace LearningManagementSystem.App.ViewModels
{
    public class QuestionResultDto
    {
        public Guid QuestionResultId { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}