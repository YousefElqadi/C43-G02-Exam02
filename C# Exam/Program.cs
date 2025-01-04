namespace C__Exam
{
    using System;
    using System.Collections.Generic;

    namespace ExaminationSystem
    {
        public abstract class Question
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public int Mark { get; set; }
            public Answer[] Answers { get; set; }
            public Answer CorrectAnswer { get; set; }

            public Question(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
            {
                Header = header;
                Body = body;
                Mark = mark;
                Answers = answers;
                CorrectAnswer = correctAnswer;
            }

            public override string ToString()
            {
                return $"{Header}\n{Body}\nMark: {Mark}";
            }
        }

        // Derived Question Types
        public class TrueOrFalseQuestion : Question
        {
            public TrueOrFalseQuestion(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
                : base(header, body, mark, answers, correctAnswer) { }
        }

        public class MCQQuestion : Question
        {
            public MCQQuestion(string header, string body, int mark, Answer[] answers, Answer correctAnswer)
                : base(header, body, mark, answers, correctAnswer) { }
        }

        // Answer Class
        public class Answer
        {
            public int AnswerId { get; set; }
            public string AnswerText { get; set; }

            public Answer(int id, string text)
            {
                AnswerId = id;
                AnswerText = text;
            }

            public override string ToString()
            {
                return $"{AnswerId}. {AnswerText}";
            }
        }

        // Base Exam Class
        public abstract class Exam
        {
            public int Time { get; set; }
            public int NumberOfQuestions { get; set; }
            public List<Question> Questions { get; set; }

            public Exam(int time, int numberOfQuestions)
            {
                Time = time;
                NumberOfQuestions = numberOfQuestions;
                Questions = new List<Question>();
            }

            public abstract void ShowExam();
        }

        // Derived Exam Types
        public class FinalExam : Exam
        {
            public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

            public override void ShowExam()
            {
                Console.WriteLine("Final Exam:");
                foreach (var question in Questions)
                {
                    Console.WriteLine(question);
                    foreach (var answer in question.Answers)
                    {
                        Console.WriteLine(answer);
                    }
                }
            }
        }

        public class PracticalExam : Exam
        {
            public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) { }

            public override void ShowExam()
            {
                Console.WriteLine("Practical Exam:");
                foreach (var question in Questions)
                {
                    Console.WriteLine(question);
                    foreach (var answer in question.Answers)
                    {
                        Console.WriteLine(answer);
                    }
                    Console.WriteLine($"Correct Answer: {question.CorrectAnswer}");
                }
            }
        }
        public class Subject
        {
            public int SubjectId { get; set; }
            public string SubjectName { get; set; }
            public Exam SubjectExam { get; set; }

            public Subject(int id, string name)
            {
                SubjectId = id;
                SubjectName = name;
            }

            public void CreateExam(Exam exam)
            {
                SubjectExam = exam;
            }

            public override string ToString()
            {
                return $"{SubjectName} (ID: {SubjectId})";
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var answers = new[]
                {
                new Answer(1, "True"),
                new Answer(2, "False")
            };

                
                var question1 = new TrueOrFalseQuestion("Q1", "The earth is flat.", 5, answers, answers[1]);

                
                var exam = new PracticalExam(60, 1);
                exam.Questions.Add(question1);

                
                var subject = new Subject(101, "Science");
                subject.CreateExam(exam);

                Console.WriteLine(subject);
                subject.SubjectExam.ShowExam();
            }
        }
    }
}
