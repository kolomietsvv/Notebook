The application allows to store, add, update and delete notes in notebook.

To build the solution you need to execute command 'Update-Package -Reinstall -ProjectName Notebook.PL.WebAPI' in package manager console.

You can change the path of notebook file in \Notebook\Notebook.PL.WebAPI\Web.config file in
connectionString \<add name="file" connectionString="../../notes.csv" />.

Also you can change the note fields separator in appSetting \<add key="fieldSeparator" value=" " />.

If you prefer not to change Web.config file, run your application/visual studio as administrator.

