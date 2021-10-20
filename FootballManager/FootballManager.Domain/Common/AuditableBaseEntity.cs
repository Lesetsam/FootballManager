﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime FirstValid { get; set; }
        public DateTime LastValid { get; set; }
    }
}
