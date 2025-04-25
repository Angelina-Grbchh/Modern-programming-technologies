using System.Threading;
using Xunit;
using DeadlockDemo;

namespace DeadlockDemo.Tests
{
    public class DeadlockTests
    {
        [Fact]
        public void Deadlock_Should_Happen()
        {
            Thread thread1 = new Thread(Program.DoWork1);
            Thread thread2 = new Thread(Program.DoWork2);

            thread1.Start();
            thread2.Start();

            bool finished1 = thread1.Join(2000);
            bool finished2 = thread2.Join(2000);

            Assert.False(finished1 && finished2, "Дедлок не виник: обидва потоки завершилися");
        }
    }
}
