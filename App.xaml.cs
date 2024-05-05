namespace JMacasS5
{
    public partial class App : Application
    {
        public static PersonRepository personRepo { get; set; }

        public App(PersonRepository personRepository)
        {
            InitializeComponent();

           // MainPage = new AppShell();
           MainPage=new NavigationPage(new Vistas.VPersona());
            personRepo = personRepository;
        }
    }
}
