using System;
using System.Collections.Generic;
using TaskPaperParser.Types;

namespace TaskPaperParser
{
    public class TaskPaperSolution
    {
        private Project currentProject;
        private Todo currentTodo;

        public TaskPaperSolution()
        {
            Projects = new List<Project>();
        }

        public List<Project> Projects { get; }

        internal void Add(Tag tag)
        {
            currentTodo.Add(tag);
        }

        public void Add(Project project)
        {
            Projects.Add(project);
            currentProject = project;
        }

        public void Add(Todo todo)
        {
            currentProject.Add(todo);
            currentTodo = todo;
        }
    }
}