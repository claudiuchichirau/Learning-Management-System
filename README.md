# Learning-Management-System (LMS) Project
The Learning Management System (LMS) is a web-based platform that allows users to access educational content, enroll in courses, watch video lectures, take quizzes, and track their progress. In this project, we’ll build an LMS using Python, PostgreSQL databases, and ML.NET for personalized course recommendations.

# Video Demo: https://youtu.be/nzUfBjaDO_g

# Features
1. **User Authentication and Registration**:
Users can create accounts, log in, and manage their profiles.
2. **Course Enrollment**:
Users can browse available courses and enroll in their preferred ones.
3. **Course Content**:
Each course consists of chapters (video lectures and accompanying PDFs).
4. **Chapter Completion**:
Users can mark chapters as completed after watching the video and reading the material.
5. **Quiz Assessment**:
At the end of each chapter, users take quizzes related to the content.
6. **Progress Tracking**:
Users can view their progress percentage for each enrolled course.

# Database Structure
1. **Users Database** (PostgreSQL):
Stores user information (username, email, hashed passwords, etc.).
2. **Courses & Chapters Database** (PostgreSQL):
Contains course details (course name, description, instructor, etc.). Stores chapter information (video URLs, PDF links, quiz questions, etc.).

# User Journey
Let’s walk through the user journey step by step:

1. **User Registration**:
A new user creates an account by providing their details (username, email, password).
2. **Course Search and Enrollment**:
The user browses available courses, selects one, and enrolls.
3. **Chapter Interaction**:
The user starts the course and begins the first chapter.
They watch the video lecture and read the accompanying PDF material.
4. **Quiz Completion**:
After studying the chapter, the user takes the quiz related to that chapter.
The system evaluates their answers and provides feedback.
5. **Progress Tracking**:
In the user’s account dashboard, they can see their progress percentage for the enrolled course.

