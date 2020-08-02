using FinalBoss.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBoss.Api.Services
{
    public interface IDataService<T> where T : BaseEntity, new()
    { }
}
