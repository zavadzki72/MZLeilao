using System;

namespace Leilao.Domain.Interfaces.Entities {

    public interface IBaseEntity {
    
        Guid Id { get; set; }
        DateTime CreationDate { get; set; }
        DateTime UpdateDate { get; set; }
    
    }
}
