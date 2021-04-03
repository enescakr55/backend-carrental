using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RequiredScore:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int MinimumScore { get; set; }

    }
}
