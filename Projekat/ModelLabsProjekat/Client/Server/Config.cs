﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Server
{
    public class Config
    {

        private string resultDirecotry = string.Empty;

        public string ResultDirecotry
        {
            get { return resultDirecotry; }
        }

        private Config()
        {
            resultDirecotry = ConfigurationManager.AppSettings["ResultDirecotry"];

            if (!Directory.Exists(resultDirecotry))
            {
                Directory.CreateDirectory(resultDirecotry);
            }
        }

        #region Static members

        private static Config instance = null;

        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Config();
                }

                return instance;
            }
        }

        #endregion Static members
    }
}
