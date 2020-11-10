using System;

namespace Leilao.ApplicationService.ViewModels.Response {

    public class UserResponseViewModel {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

    }
}
