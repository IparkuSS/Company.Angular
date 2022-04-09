# APINews
1. Set SECRET as a variable env.
2. Make a migration to add the default user to the database.
3. In the project properties, click Run Multiple Projects, and select projects APINews and MVCNews.
3. Compile the project.
4. Follow the link login.
5. Enter login and password
   * If the data is valid you will be given jwt token
6. In the url line, enter the role under which you are logged in
   * Redactor or Administrator
---
In the project structure, data from APINews represents the server role, where data is exchanged with the database and the MVCNews takes this data through httpclient and transfers this data to the view.

