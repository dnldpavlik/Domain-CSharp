namespace DonPavlik.Task.Test
{
    using DonPavlik.Domain.Task;
    using System;
    using Xunit;

    /// <summary>
    /// Test Class used to test the functionality of the Task
    /// Domain class.
    /// </summary>
    public class TaskTests
    {
        /// <summary>
        /// Local test task instance used for testing
        /// </summary>
        private ITask _testTask;

        /// <summary>
        /// Local test value for default date time
        /// </summary>
        private TimeSpan _testTime = new TimeSpan();

        /// <summary>
        /// Initializes a new instance of Task for each test
        /// </summary>
        private void InitializeTestTask()
        {
            this._testTask = new Task();
        }

        /// <summary>
        /// Test to see if a new task has the standard default
        /// values.
        /// </summary>
        [Fact]
        public void TestInitializedTaskDefaults()
        {
            this.InitializeTestTask(); 

            Assert.Null(this._testTask.Description);
            Assert.Null(this._testTask.Note);
            Assert.False(this._testTask.Blocked);
            Assert.False(this._testTask.IsCompleted);
            Assert.False(this._testTask.InProgress);
            Assert.Equal(this._testTask.SubTasks.Count, 0);
            Assert.Equal(this._testTime, this._testTask.TimeTaken);
        }

        /// <summary>
        /// Tests to see if the value assigned to Note is the
        /// same being returned.
        /// </summary>
        [Fact]
        public void TestNoteAssignment()
        {
            this.InitializeTestTask(); 
            string testDescription = "Test Task";
            this._testTask.Description = testDescription;

            Assert.Equal(testDescription, this._testTask.Description);
        }

        /// <summary>
        /// Tests to see if the value asssigned to Description
        /// is the same being returend.
        /// </summary>
        [Fact]
        public void TestDescriptionAssignment()
        {
            this.InitializeTestTask();
            string testNote = "Test Note";
            this._testTask.Note = testNote;

            Assert.Equal(testNote, this._testTask.Note);
        }

        /// <summary>
        /// Tests to see if calling the start method on a
        /// task marks the task as in progress
        /// </summary>
        [Fact]
        public void TestStartTaskIsInProgress()
        {
            this.InitializeTestTask();
            this._testTask.Start();

            Assert.True(this._testTask.InProgress);
        }

        /// <summary>
        /// Tests to see if the calling the pause method on
        /// a task that has not been started has not updated
        /// the time taken and task is not in progress
        /// </summary>
        [Fact]
        public void TestPauseTaskOfNoneStartedTaskIsNotInProgressAndHasBadTimeTaken()
        {
            this.InitializeTestTask();
            this._testTask.Pause();

            Assert.False(this._testTask.InProgress);
            Assert.Equal(this._testTime, this._testTask.TimeTaken);
        }

        /// <summary>
        /// Tests a task to see if a task that has been started
        /// and then paused have its In progress back to false
        /// and the time taken has been updated.
        /// </summary>
        [Fact]
        public void TestPausingATaskThatHasBeenStarted()
        {
            this.InitializeTestTask();
            this._testTask.Start();
            this._testTask.Pause();
            TimeSpan oneMilisecond = new TimeSpan(0, 0, 0, 0, 1);

            Assert.False(this._testTask.InProgress);
            Assert.NotEqual(this._testTime, this._testTask.TimeTaken);
            Assert.True(oneMilisecond <= this._testTask.TimeTaken);
        }

        /// <summary>
        /// Tests to see when starting and pausing a task a couple of times in a row
        /// that the time taken is greater than the previous time taken
        /// </summary>
        [Fact]
        public void TestStartPauseStartPauseTimeTakenAccumlatingCorrectly()
        {
            this.InitializeTestTask();
            this._testTask.Start();
            this._testTask.Pause();
            TimeSpan timeTaken = this._testTask.TimeTaken;

            this._testTask.Start();
            this._testTask.Pause();

            Assert.True(timeTaken < this._testTask.TimeTaken);
        }

        /// <summary>
        /// Tests that a task when completed a task property is marked true
        /// </summary>
        [Fact]
        public void TestCompletedTask()
        {
            this.InitializeTestTask();
            this._testTask.Complete();

            Assert.True(this._testTask.IsCompleted);
        }

        /// <summary>
        /// Tests that a completed start task has updates the time taken
        /// </summary>
        [Fact]
        public void TestStartedTaskCompeletedTimeTakenUpdated()
        {
            this.InitializeTestTask();
            this._testTask.Start();
            this._testTask.Complete();

            TimeSpan oneMilisecond = new TimeSpan(0, 0, 0, 0, 1);

            Assert.NotEqual(this._testTime, this._testTask.TimeTaken);
            Assert.True(oneMilisecond <= this._testTask.TimeTaken);
        }
    }
}
