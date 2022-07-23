﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Models
{
    public class UserTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Comments { get; set; }

        public bool IsComplete { get; set; }

        public int Priority { get; set; }

        public DateTime DueTime { get; set; }

        public int ProjectId { get; set; }
    }
}
