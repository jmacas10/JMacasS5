using JMacasS5.Models;

namespace JMacasS5.Vistas;

public partial class Veditar : ContentPage
{
    Persona persona;
    public Veditar(Persona _persona)
    {
       
        VPersona vp = new VPersona();
        InitializeComponent();
        persona = _persona; // Guarda la persona que se va a editar
        BindingContext = persona; // Establece el contexto de enlace con la persona
        


    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        // Actualiza la información de la persona
        persona.Name = txtNombre.Text;
        App.personRepo.UpdatePerson(persona); // Actualiza la persona en la base de datos
        
       
        Navigation.PopAsync(); // Vuelve a la página anterior

        (App.Current.MainPage as NavigationPage)?.Navigation.PopAsync();
        (App.Current.MainPage as NavigationPage)?.Navigation.PushAsync(new VPersona());

      //  VPersona vp = new VPersona();
        //vp.listarPerosna();
    

      
    }
}