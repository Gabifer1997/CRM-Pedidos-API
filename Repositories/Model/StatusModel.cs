﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Model
{
    public class StatusModel
    {
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public bool Apagado { get; set; }
    }
    public class StatusRequestModel
    {
        public string Descricao { get; set; }
    }
}
