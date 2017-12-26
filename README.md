Final Assignment Project for SoftUni Practical Teamwork Course.  
<br>
Collaborators: 
- Maria Kancheva 
- Peter Iliev 
- Yavor Vasilev 
- Georgi Georgiev 
- Ivelin Arnaudov 
- Simeon Georgiev  

Стъпки за използване на ViewModel през MVVM Pattern:

1: Правите ViewModel, наследяващ ViewModelBase

public class LoginFormViewModel : ViewModelBase

2: За всяко поле слагате обикновено пропърти:

public string Username { get; set; }

3: За всеки бутон слагате ICommand пропърти. Всяка команда от своя страна изпълнява долната логика:

public ICommand Login
{
	get
	{
		if (this.LoginCommand == null) <--(това е private ICommand Field)
		{
			this.LoginCommand = new RelayCommand(this.Handle[ИмеНаКоманда]Command);
		}
		return this.LoginCommand;
	}
}

4: Горния getter препраща към логиката на метода:

public void Handle[ИмеНаКоманда]Command(object parameter)
{
	var box = (PasswordBox)parameter;
	var pass = box.Password;

	var hashedPass = HashToSha1(pass);

	var userService = new UserService();

	userService.LoginUser(this.Username, hashedPass);
}

5: Към съответните методи и пропъртита се слагат Binding пропъртита на полетата/бутоните в XAML:

<Button x:Name="closeBtn"
                    Content="Close" 
                    Margin="179,223,49.8,67.6" 
                    Background="#FF852035" 
                    Foreground="White" 
                    FontSize="18" 
                    Command="{Binding Close}" /> <- Това е за бутон
					
<TextBox Name="UsernameBox" 
                         Background="#545d6a" 
                         Foreground="White" 
                         FontSize="18" 
                         Text="{Binding Username}"/> <- Това е за поленце
						 
6: За да се възползвате от ViewModel-а, трябва да BUILD-нете и след това да направите връзка от XAML през namespace:

xmlns:viewModels="clr-namespace:BmsWpf.ViewModels" <- слага се като атрибут на Window/Control елемента

7: Връзва се към модела по namespace. Парчето код се добавя СЛЕД описанието на Window/Control и ПРЕДИ всичко останало, включително <border>:

<UserControl.DataContext>
	<viewModels:LoginFormViewModel />
</UserControl.DataContext>

8: Ако всичко е преминало без грешки, не ви трябва нищо друго - включително и ButtonClick събития.
Не е задължително да подавате параметри - аз го правя, за да използвам коректно паролата.

HAVE FUN!