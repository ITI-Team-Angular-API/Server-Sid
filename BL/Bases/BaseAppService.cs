﻿using AutoMapper;
using BL.Configur;
using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class AppServiceBase : IDisposable
    {
        #region Vars
        protected IUnitOfWork TheUnitOfWork { get; set; }
        protected readonly IMapper Mapper = MapperConfig.Mapper;
        #endregion

        #region CTR
        public AppServiceBase()
        {
            TheUnitOfWork = new UnitOfWork();
        }

        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }
        #endregion
    }
}
