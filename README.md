# Risotto Reservations
Reservation website utilizing backend MVC design pattern. Purpose of the project highlights techniques used connecting frontend to backend and retrieves information stored on local database (Microsoft SQL Management System)

![alt tag](https://github.com/Peter-Palacios/Strata-site/blob/master/images/ProjectGifs/Risotto.gif)

## How It's Made:

**Tech used:** HTML, CSS, JavaScript, ASP.NET Core, C#, T-SQL

Started building project by using frontend template that used JavaScript, HTML and CSS. Incorporated own ideas into front-end part of application. After front-end was in place started building Reservation Model and relevant Controllers and Views that followed. After making the the MVC part of the application, incorporated CRUD methods to the application and stored data temporarily in application. Afterwards, adjusted model to include storing data onto Microsoft SQL Server Management Studio. Afterwards added User Model to allow different users to create an account and login to store their reservation information, as well as having an admin login to view all customer reservations and apply CRUD operations. (Authentication/Authorization added)

## Optimizations

Changed reservation creation to not need customers to create their own Id per reservation to have a more realistic approach and have self-incrementation build into reservation Ids.
## Lessons Learned:

Learned more about backend application development and the importance of having structured code that communicates well with the database. Learned through fixing the database with bugs that code that isn't structured can lead to very long term problems as more information is stored and may need to be corrected.


