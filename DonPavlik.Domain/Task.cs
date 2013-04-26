namespace DonPavlik.Domain.Task
{
    using System;
    using System.Collections.Generic;

    public class Task : ITask
    {
        /// <summary>
        /// Internal Variable that holds the last known start time of the task
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// Instanciates a new class instance of Task class
        /// </summary>
        public Task()
        {
            this.SubTasks = new List<ITask>();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the description of the Task
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the note of the Task
        /// </summary>
        public string Note
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the value indicating whether the task is blocked or not
        /// </summary>
        public bool Blocked
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the value indicating whether the task is completed
        /// </summary>
        public bool IsCompleted
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the value indicating whether the task is in progress
        /// </summary>
        public bool InProgress
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the collection of Sub Tasks for the Task
        /// </summary>
        public List<ITask> SubTasks
        {
            get;
            private set;
        }

        /// <summary>
        /// Used to get the Time Taken for the Task
        /// </summary>
        public TimeSpan TimeTaken
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// Logs the time taken from the start time to current time to time taken.
        /// If time taken is less than a second, will just add 1 second to the time
        /// taken, as this is not something humanly possible to do, and would only 
        /// occur if a machine was starting/pausing/completing a task right after 
        /// another.
        /// </summary>
        private void LogTime()
        {
            if (this._startTime != new DateTime())
            {
                TimeSpan takenTime = 
                    DateTime.Now - this._startTime;
                
                if (takenTime.Seconds <= 0)
                {
                    takenTime = new TimeSpan(0, 0, 1);
                }

                this.TimeTaken += takenTime;
            }
        }

        #region Public Methods

        /// <summary>
        /// Completes the task and updates the status IsComplete to true
        /// </summary>
        public void Complete()
        {
            this.IsCompleted = true;
            this.LogTime();
        }

        /// <summary>
        /// Pauses the task and resets InProgress to false
        /// </summary>
        public void Pause()
        {
            this.InProgress = false;
            this.LogTime();
        }

        /// <summary>
        /// Starts the tasks and sets InProgress to true
        /// </summary>
        public void Start()
        {
            this.InProgress = true;

            this._startTime = DateTime.Now;
        }

        #endregion
    }
}
