using System;
using Xunit;

namespace GradeBook.test
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverage()
        {
            //arrange
            BookInMemory book = new BookInMemory("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            

            /*int x = 5;
            int y =10;
            int expect = 15;*/

            //act

            Statistics result=  book.GetStatistic();
            //int actual = 5+10;


            //assert

            book.GetStatistic();
            Assert.Equal(85.6, result.average,1);
            Assert.Equal(90.5, result.highGrade);
            Assert.Equal(77.3, result.lowGrade);
            Assert.Equal('B',result.letter);

            //Assert.Equal(expect,actual);

        }
    }
}
