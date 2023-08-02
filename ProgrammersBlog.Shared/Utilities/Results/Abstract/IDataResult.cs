using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        public T Data { get; } // new DataResult<CAtegory>(ResultStatus.Success,category);
                               // new DataResult<IList<CAtegory>>(ResultStatus.Success,category);

    }
}
