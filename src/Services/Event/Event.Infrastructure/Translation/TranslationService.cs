﻿using Event.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.Translation
{
    public class TranslationService : ITranslationService
    {
        public string Translate(string key)
        {
            return key;
        }
    }
}
