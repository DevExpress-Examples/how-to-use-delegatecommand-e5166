Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Mvvm
Imports System.Windows

Namespace Example.ViewModel
	Public Class MainViewModel
		Inherits ViewModelBase
		Private privateTestCommand As DelegateCommand
		Public Property TestCommand() As DelegateCommand
			Get
				Return privateTestCommand
			End Get
			Private Set(ByVal value As DelegateCommand)
				privateTestCommand = value
			End Set
		End Property
		Public Property IsTestCommandEnabled() As Boolean
			Get
				Return GetProperty(Function() IsTestCommandEnabled)
			End Get
			Set(ByVal value As Boolean)
				SetProperty(Function() IsTestCommandEnabled, value)
			End Set
		End Property
		Private Sub Test()
			MessageBox.Show("Hello")
		End Sub
		Private Function CanTest() As Boolean
			Return IsTestCommandEnabled
		End Function

		Private privateUpdateTestCommand As DelegateCommand
		Public Property UpdateTestCommand() As DelegateCommand
			Get
				Return privateUpdateTestCommand
			End Get
			Private Set(ByVal value As DelegateCommand)
				privateUpdateTestCommand = value
			End Set
		End Property
		Private Sub UpdateTest()
			TestCommand.RaiseCanExecuteChanged()
		End Sub

		Private privateCommandWithParameter As DelegateCommand(Of String)
		Public Property CommandWithParameter() As DelegateCommand(Of String)
			Get
				Return privateCommandWithParameter
			End Get
			Private Set(ByVal value As DelegateCommand(Of String))
				privateCommandWithParameter = value
			End Set
		End Property
		Private Sub CommandWithParameterExecute(ByVal parameter As String)
			MessageBox.Show(parameter)
		End Sub
		Private Function CommandWithParameterCanExecute(ByVal parameter As String) As Boolean
			Return Not String.IsNullOrEmpty(parameter)
		End Function

		Public Sub New()
			TestCommand = New DelegateCommand(AddressOf Test, AddressOf CanTest)
			UpdateTestCommand = New DelegateCommand(AddressOf UpdateTest)
			CommandWithParameter = New DelegateCommand(Of String)(AddressOf CommandWithParameterExecute, AddressOf CommandWithParameterCanExecute)
		End Sub
	End Class
End Namespace
