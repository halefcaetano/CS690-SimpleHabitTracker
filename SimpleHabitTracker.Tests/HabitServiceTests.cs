using Xunit;
using SimpleHabitTracker;

public class HabitServiceTests
{
    [Fact]
    public void CanAddHabit()
    {
        var service = new HabitService();
        service.AddHabit("Read");

        var habits = service.GetHabits();
        Assert.Single(habits);
        Assert.Equal("Read", habits[0].Name);
    }
}

