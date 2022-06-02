using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace QTDemoDefaultViews.WpfApp.ViewModels
{
    public class PersonsViewModel : BaseViewModel
    {
        public ObservableCollection<Logic.Entities.Person> Persons
        {
            get
            {
                using var ctrl = new Logic.Controllers.PersonsController();
                var entities = Task.Run(async () => await ctrl.QueryByAsync(firstName, lastName).ConfigureAwait(false)).Result;

                return new ObservableCollection<Logic.Entities.Person>(entities.OrderBy(e => e.LastName).ThenBy(e => e.FirstName));
            }
        }

        private int windowHeight = 700;
        public int WindowHeight
        {
            get
            {
                return windowHeight;
            }
            set
            {
                windowHeight = value;
            }
        }
        private int windowWidth = 800;
        public int WindowWidth
        {
            get
            {
                return windowWidth;
            }
            set
            {
                windowWidth = value;
                OnPropertyChanged(nameof(DataItemWidth));
            }
        }
        public int DataItemWidth
        {
            get
            {
                return windowWidth - 100;
            }
        }

        private string? firstName;

        public string? FirstName
        {
            get { return firstName; }
            set 
            {
                firstName = value;
                OnPropertyChanged(nameof(Persons));
            }
        }
        private string? lastName;

        public string? LastName
        {
            get { return lastName; }
            set 
            {
                lastName = value;
                OnPropertyChanged(nameof(Persons));
            }
        }
    }
}
