# Tutorized

Tutorized Application is a system that allows students to schedule time with a tutor in their subject of expertise. Once the appointment has been requested by the student, the tutor accepts this appointment. Additionally, this system provides the ability for a student and the tutor to chat. This application ensures that students are getting as much help as they need in a timely, organized manner.

## Getting Started
Clone (as shown below) or download this project onto your desired location. 

```
git clone https://github.com/UWF-HMCSE-CS/SEM2018_Group5.git
```
Or, you can access our website by visiting:  http://tutorized.azurewebsites.net/

### Installing
If you chose to clone the project, once downloaded, open the project solution file (.sln) in Visual Studio or any other preferred IDE. 
Once the project has been loaded, you want to install the node packages before executing the program. 

If you are using Microsoft's Visual Studio, you can install the node packages by:

```
Tools -> NuGet Packet Manager -> Package Manager Console
```
Once the console is displayed, type the following to ensure you install the packages inside the correct folder. 

Step 1: get to the correct folder
```
cd .\TUTORized
```
Step 2: install the node packages
```
npm install
```

## Running the program
After reading the description above, you must have figured out that our application is used for both students and tutors, hence the following steps (along with sample images on the bottom of each step) will be shown using both users. 


### Login as a Tutor
1. The first screen will have you log in, but you will need to sign up before you log in, so click on the "Sign up" button. 
![image](https://user-images.githubusercontent.com/14351534/47764955-b3d33000-dc95-11e8-8d0a-9807be93dbd6.png)


2. Here, it will ask you to enter your first and last name, email id, password and indicate that you are a tutor.
![image](https://user-images.githubusercontent.com/14351534/47765026-044a8d80-dc96-11e8-936a-8f48d4e2bf52.png)


3. Once you are signed up, it will take you back to the log in page, where you will log in. 
![image](https://user-images.githubusercontent.com/14351534/47765059-25ab7980-dc96-11e8-9fd6-34ed23ff57b2.png)


4. After logging in, you will see a page that will welcome you to our website! 
![k](https://user-images.githubusercontent.com/25124387/49679568-f258c900-fa51-11e8-8b4f-90d422a8462f.JPG)

### Tutors Can Create An Available Appointment (Build Their Schedule)
1. On the left hand side, one of the menus on the navigation bar will have "Create New Appointment" where you will want to go next.
![image](https://user-images.githubusercontent.com/14351534/47765265-1c6edc80-dc97-11e8-91cd-c1b0563ed77b.png)


2. This will ask you to enter the subject you are tutoring in along with your available date and time, click on the submit button to release your appointment to the student. 
![image](https://user-images.githubusercontent.com/14351534/47765531-699f7e00-dc98-11e8-8717-d19fc3909a0d.png)


3. Your appointment will be shown on the calendar and once a student confirms it, you will receive an Email confirmation, and your calendar will have their name on it (compare the two images below, one without the student's name which means nobody has taken up that appointment versus the one that has a name of a student which has confirmed your appointment). ![image](https://user-images.githubusercontent.com/14351534/47765583-9fdcfd80-dc98-11e8-8c2d-5530948c9467.png) ![image](https://user-images.githubusercontent.com/14351534/47765604-bc793580-dc98-11e8-990b-2303979f404a.png)

### Tutors Can Upgrade Students to Tutor
1. Navigate to the "Approve New Tutors" page by selecting "Approve New Tutors" from the nav menu
![l](https://user-images.githubusercontent.com/25124387/49679576-fedd2180-fa51-11e8-8ce9-4ae0a3c821f5.jpg)


Currently all Tutors have the capability to upgrade a capable Student to Tutor status. In our next release there will be a verification process put into place to require an approval authority. Additionally, there will be a capability to accept requests from non-students to be vetted and approved to tutor students. 


2. Next use the drop down menu to select a Student you wish to upgrade to Tutor
![m](https://user-images.githubusercontent.com/25124387/49679581-0ac8e380-fa52-11e8-9452-a6afc86679da.jpg)
![n](https://user-images.githubusercontent.com/25124387/49679588-14eae200-fa52-11e8-81c4-70d897414e1c.jpg)


3. Once the correct Student is selected click "Submit" and you will recieve a notification once the upgrade is complete
![o](https://user-images.githubusercontent.com/25124387/49679593-1ddbb380-fa52-11e8-952a-268ecce1ea02.jpg)
![p](https://user-images.githubusercontent.com/25124387/49679597-27651b80-fa52-11e8-9bce-5de03e747278.jpg)


### Login as a Student
1. The first screen will have you log in, but you will need to sign up before you log in, so click on the "Sign up" button. 
![image](https://user-images.githubusercontent.com/14351534/47764955-b3d33000-dc95-11e8-8d0a-9807be93dbd6.png)


2. Here, it will ask you to enter your first and last name, email id, password and indicate that you are a student. 
![image](https://user-images.githubusercontent.com/14351534/47764999-e67d2880-dc95-11e8-8d29-fc4ffaff3fb4.png)


3. Once you are signed up, it will take you back to the log in page, where you will log in. 
![image](https://user-images.githubusercontent.com/14351534/47765047-19bfb780-dc96-11e8-9897-3b5f034e1d7e.png)


4. After logging in, you will see a page that will welcome you to our website! 
![a](https://user-images.githubusercontent.com/25124387/49679499-752d5400-fa51-11e8-8d09-bb1beddf9d06.JPG)


### Schedule an Appointment as a Student
1. On the left hand side, one of the menus on the navigation bar will say "Schedule An Appointment", that is where you will want to go next. 
![b](https://user-images.githubusercontent.com/25124387/49679508-82e2d980-fa51-11e8-81cb-9ad30ef87d1e.JPG)


2. This dropbox box will show you a list of available tutor appointments, select an appointment and then click on the submit button to confirm your appointment. 
![c](https://user-images.githubusercontent.com/25124387/49679512-8d04d800-fa51-11e8-9ca2-0a0b4fbdae1d.jpg)
![d](https://user-images.githubusercontent.com/25124387/49679518-98580380-fa51-11e8-996a-310a175c2113.jpg)
![e](https://user-images.githubusercontent.com/25124387/49679526-a1e16b80-fa51-11e8-9d69-cba8d707a790.jpg)


3. Once you confirm it, you will get be alerted saying "Scheduled Successfully".
![f](https://user-images.githubusercontent.com/25124387/49679530-ad349700-fa51-11e8-886d-bcef8c8cbef5.JPG)


4. The appointment you just confirmed will be displayed on your calendar along with the date, time and the name of your tutor.
![ff](https://user-images.githubusercontent.com/25124387/49680095-9e9cae80-fa56-11e8-9a12-3359041efb6c.JPG)


#### Using the Search Bar on the Schedule An Appointment Page
1. If you wish to search an appointment you can type either the Tutors name or the Subject you wish to filter by, and click "Apply Filter" and you will get a notification that the Appointments were filtered successfully.
![g](https://user-images.githubusercontent.com/25124387/49679535-b887c280-fa51-11e8-8b10-f1b68f4409ea.jpg)
![h](https://user-images.githubusercontent.com/25124387/49679538-c2a9c100-fa51-11e8-8285-1e4242057a3d.jpg)

2. Next, use the drop down box; you will notice that it is now filtered. Select the Appointment you wish to schedule, and finish the appointment scheduling process as described above.
![i](https://user-images.githubusercontent.com/25124387/49679554-d9e8ae80-fa51-11e8-82bd-6399773a1f6e.jpg)
 
3. If, after you have applied a filter, you wish to reset it and filter for a different Tutor or Subject; simply click the "Reset Filter" button. At this point you can start over from step one and start your search again, or simply use the drop down menu and select from the entire list of Appointments.
![j](https://user-images.githubusercontent.com/25124387/49679560-e3721680-fa51-11e8-8289-6f86a129fe58.jpg)


### Viewing Users (Tutors or Students) you have worked with
1. After you have logged in (discribed above), select the correct tab based on what "Role" you are logged in under. 
  
  A) Logged in as "Tutor"
  ![image](https://user-images.githubusercontent.com/25124387/48272551-79d7fb80-e404-11e8-960d-3d22076c8b3a.png)
  
  B) Logged in as "Student"
  ![image](https://user-images.githubusercontent.com/25124387/48272702-df2bec80-e404-11e8-82f6-dce5e61e22d0.png)


2. Next you will be able to see who you have worked with, or if you have not worked with anyone yet.

  A) Displays the Users you have worked with
  ![image](https://user-images.githubusercontent.com/25124387/48272748-02ef3280-e405-11e8-80c4-e50367312771.png)
  
  B) Informs you that you have not worked with another User yet
  ![image](https://user-images.githubusercontent.com/25124387/48272803-1a2e2000-e405-11e8-8d29-f58dd645d68c.png)
  
### Messaging a User (Tutors or Students) you have worked with
1. After you have logged in (described above), select the 'Messages' tab to chat with a user you have worked with. If you are a tutor, you can only chat with students you have worked with. If you are a student, you can only chat with tutors you have worked with.

#### Logged in as a "Tutor" or a "Student"
1. Select a user, type your message and click on the send button. That message will appear under 'List of your sent messages:' 
You can view their messages by looking at the 'List of your received messages'.
![image](https://user-images.githubusercontent.com/14351534/48653810-6d880b80-e9cd-11e8-9f56-812d663d4016.png)

![image](https://user-images.githubusercontent.com/14351534/48653823-85f82600-e9cd-11e8-8d13-b7f4c835b4b2.png)

![image](https://user-images.githubusercontent.com/14351534/48653841-9f996d80-e9cd-11e8-8123-0138351e29f7.png)

![image](https://user-images.githubusercontent.com/14351534/48654040-3581c800-e9cf-11e8-8f1e-8a24d6708584.png)


### Sharing a Resource with a Student/Tutor you have worked with
After you have logged in (described above), select the 'Resources' tab to share a resource with a user you have worked with. If you are a tutor, you can only share with students you have worked with. If you are a student, you can only share with tutors you have worked with. 

Currently a student or a tutor can only select the file to be uploaded. In our next release there will be a capability to select a user and send that file that you selected to upload. Additionally, you will be able to look at the files sent from you and sent to you. 


### Logged in as a "Tutor" or a "Student"
1. Select the Resources tab
![image](https://user-images.githubusercontent.com/14351534/49680506-b0805080-fa5a-11e8-97ef-c247f42a95f4.png)

2. And you should see a page similar to this. 
![image](https://user-images.githubusercontent.com/14351534/49680514-cc83f200-fa5a-11e8-9b75-3fac0bce65fb.png)

3. Click "browse" to select a file, once selected the name of the file will show up to ensure you have got the correct file.
![image](https://user-images.githubusercontent.com/14351534/49680540-1ec51300-fa5b-11e8-8488-fcf5d139e852.png)

4. Once you're done, click on upload to send it and you should get a message saying the upload was successful. 
![image](https://user-images.githubusercontent.com/14351534/49680553-4916d080-fa5b-11e8-92ba-fa1b99cc39fd.png)


## Running the tests
You can run the tests by going to the 'Test' menu, then 'Run' and 'All Tests', an image is provided below: 

![screenshot 14](https://user-images.githubusercontent.com/14351534/47696360-75297100-dbd4-11e8-8313-ed8b224eff08.png)

## Built with
* [Vuetify](https://vuetifyjs.com/en/) - A componenet framework for Vue.js
* [Dapper](https://dapper-tutorial.net/) - An ORM mapping framework


## Authors

**Wesley Easton**

**Timothy McWatters**

**Keenal Shah**

**Wenwen Xu**


