using System;
namespace Quiz
{
    public sealed class StatisticsSingleton
    {
        private static readonly Lazy<StatisticsSingleton> lazy =
            new Lazy<StatisticsSingleton>(() => new StatisticsSingleton());

        public static StatisticsSingleton Instance => lazy.Value;

        private StatisticsSingleton()
        {
        }

        public int AnsweredQuestions => CorrectAnswers+FalseAnswers+SkippedAnswers;
        public int CorrectAnswers { get; set; } = 0;
        public int FalseAnswers { get; set; } = 0;
        public int SkippedAnswers { get; set; } = 0;
    }
}
