namespace DonPavlik.Domain.Task
{
    using System;
    using System.Collections.Generic;

    public interface ITask
    {
        #region Public Properties

        /// <summary>
        /// Gets the description of the Task
        /// </summary>
        string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the note of the Task
        /// </summary>
        string Note
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the value indicating whether the task is blocked or not
        /// </summary>
        bool Blocked
        {
            get;
        }

        /// <summary>
        /// Gets the value indicating whether the task is completed
        /// </summary>
        bool IsCompleted
        {
            get;
        }

        /// <summary>
        /// Gets the value indicating whether the task is in progress
        /// </summary>
        bool InProgress
        {
            get;
        }

        /// <summary>
        /// Gets the collection of Sub Tasks for the Task
        /// </summary>
        List<ITask> SubTasks
        {
            get;
        }

        /// <summary>
        /// Gets the time taken for the task
        /// </summary>
        TimeSpan TimeTaken
        {
            get;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Completes the task and updates the status IsComplete to true
        /// </summary>
        void Complete();

        /// <summary>
        /// Pauses the task and resets InProgress to false
        /// </summary>
        void Pause();

        /// <summary>
        /// Starts the tasks and sets InProgress to true
        /// </summary>
        void Start();

        #endregion
    }
}
