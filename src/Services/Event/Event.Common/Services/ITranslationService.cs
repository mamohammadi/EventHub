﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Common.Services
{
    public interface ITranslationService
    {
        public string Translate(string key);
    }
}
