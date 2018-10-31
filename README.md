# Tutorized

Tutorized Application is a system that allows students to schedule time with a tutor in their subject of expertise. Once the appointment has been requested by the student, the tutor accepts this appointment. Additionally, this system provides the ability for a student and the tutor to chat. This application ensures that students are getting as much help as they need in a timely, organized manner.

## Getting Started
Clone (as shown below) or download this project onto your desired location. 

```
git clone https://github.com/UWF-HMCSE-CS/SEM2018_Group5.git
```
Or, you can access our website by visiting:  http://tutorized.azurewebsites.net/

### Installing
Once downloaded, open the project solution file (.sln) in Visual Studio or any other preferred IDE. 
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
After reading the description above, you must have figured out that our application is used for both students and tutors, hence the following steps (along with sample images on the bottom of each step) will be shown using both users. We will use the name Shriya for a student and Tanuj will be our guinea tutor. 

### Login as a Student
1. The first screen will have you log in, but you will need to sign up before you log in, so click on the "Sign up" button. 
![image](https://user-images.githubusercontent.com/14351534/47764955-b3d33000-dc95-11e8-8d0a-9807be93dbd6.png)


2. Here, it will ask you to enter your first and last name, email id, password and indicate that you are a student. 
![image](https://user-images.githubusercontent.com/14351534/47764999-e67d2880-dc95-11e8-8d29-fc4ffaff3fb4.png)


3. Once you are signed up, it will take you back to the log in page, where you will log in. 
![image](https://user-images.githubusercontent.com/14351534/47765047-19bfb780-dc96-11e8-9897-3b5f034e1d7e.png)


4. After logging in, you will see a page that will welcome you to our website! 
![image](https://user-images.githubusercontent.com/14351534/47765084-3fe55780-dc96-11e8-86a7-62703aac39bf.png)


5. On the left hand side, one of the menus on the navigation bar will have "Schedule An Appointment" where you will want to go next. 
![image](https://user-images.githubusercontent.com/14351534/47765188-c26e1700-dc96-11e8-9e9f-1c17476878a8.png)


6. This dropbox box will show you a list of available tutor appointments, select an appointment and then click on the submit button to confirm your appointment. 
![image](https://user-images.githubusercontent.com/14351534/47765324-6c4da380-dc97-11e8-9def-48bc69400b4e.png)


7. Once you confirm it, you will get be alerted saying "Scheduled Successfully".
![image](https://user-images.githubusercontent.com/14351534/47765376-af0f7b80-dc97-11e8-8b2b-cfd74d6a5752.png)

8. The appointment you just confirmed will be displayed on your calendar along with the date, time and the name of your tutor.
![image](https://user-images.githubusercontent.com/14351534/47765495-39f07600-dc98-11e8-9a9e-9d1eddf4c0b4.png)



### Login as a Tutor
1. The first screen will have you log in, but you will need to sign up before you log in, so click on the "Sign up" button. 
![image](https://user-images.githubusercontent.com/14351534/47764955-b3d33000-dc95-11e8-8d0a-9807be93dbd6.png)


2. Here, it will ask you to enter your first and last name, email id, password and indicate that you are a tutor.
![image](https://user-images.githubusercontent.com/14351534/47765026-044a8d80-dc96-11e8-936a-8f48d4e2bf52.png)


3. Once you are signed up, it will take you back to the log in page, where you will log in. 
![image](https://user-images.githubusercontent.com/14351534/47765059-25ab7980-dc96-11e8-9fd6-34ed23ff57b2.png)


4. After logging in, you will see a page that will welcome you to our website! 
![image](https://user-images.githubusercontent.com/14351534/47765084-3fe55780-dc96-11e8-86a7-62703aac39bf.png)


5. On the left hand side, one of the menus on the navigation bar will have "Create New Appointment" where you will want to go next.
![image](https://user-images.githubusercontent.com/14351534/47765265-1c6edc80-dc97-11e8-91cd-c1b0563ed77b.png)


6. This will ask you to enter the subject you are tutoring in along with your available date and time, click on the submit button to release your appointment to the student. 
![image](https://user-images.githubusercontent.com/14351534/47765531-699f7e00-dc98-11e8-8717-d19fc3909a0d.png)


7. Your calendar will be shown on the calendar and once a student confirms it, it will have their name on it (compare the two images below, one without the student's name which means nobody has taken up that appointment versus the one that has a name of a student which has confirmed your appointment). ![image](https://user-images.githubusercontent.com/14351534/47765583-9fdcfd80-dc98-11e8-8c2d-5530948c9467.png) ![image](https://user-images.githubusercontent.com/14351534/47765604-bc793580-dc98-11e8-990b-2303979f404a.png)



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


