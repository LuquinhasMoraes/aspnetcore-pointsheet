﻿using pointsheet_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Data.Interfaces
{
    public interface ICargaHorariaData
    {
        IEnumerable<CargaHoraria> ObtemCargaHoraria();
    }
}