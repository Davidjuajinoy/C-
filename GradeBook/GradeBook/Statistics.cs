using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public Double highGrade;
        public Double lowGrade;
        public Double average;
        public char letter;

        public Statistics()
        {
            average = 0.0;
            highGrade = Double.MinValue;
            lowGrade = Double.MaxValue;
        }

        public void Asignar(List<Double> arrayGrade)
        {
            foreach (var item in arrayGrade)
            {
                this.average += item;
                this.highGrade = Math.Max(item, this.highGrade);
                this.lowGrade = Math.Min(item, this.lowGrade);
            }

            this.average /= arrayGrade.Count;

            switch (this.average)
            {
                case var d when d >= 90.0:
                    this.letter = 'A';
                    break;

                case var d when d >= 80.0:
                    this.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    this.letter = 'C';
                    break;

                case var d when d >= 60.0:
                    this.letter = 'D';
                    break;

                default:
                    this.letter = 'F';
                    break;
            }

        }


    }
}
