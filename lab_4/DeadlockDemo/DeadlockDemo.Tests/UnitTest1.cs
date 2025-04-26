using System.Threading;
using System.Threading.Tasks;
using Xunit;
using DeadlockDemo;

namespace DeadlockDemo.Tests
{
    public class DeadlockTests
    {
        [Fact]
        public async Task Deadlock_Should_Occur()
        {
            var task = Task.Run(() => Program.StartThreads());

            var timeoutTask = Task.Delay(2000);

            var completedTask = await Task.WhenAny(task, timeoutTask);

            // Якщо повернувся timeoutTask, значить task завис → дедлок стався
            // Якщо повернувся task, значить завдання завершилося → дедлоку нема
            Assert.False(completedTask == task, "Очікувався дедлок, але потоки завершилися успішно.");
        }
    }
}
