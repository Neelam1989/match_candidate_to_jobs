# match_candidate_to_jobs

**JobAdder Coding Challenge**

For this exercise, we’d like you to create a web application that will help a recruiter automatically match candidates to open jobs.

Within your UI, (the form the interface takes is open to your interpretation), for each job, display a candidate that is the most-qualified to fill that job.

**Approach and Description**

This app displays all jobs when the application loads where the Job id is hyperlink, if the user clicks on job id all candidates of matching skills with that job will display.

For matching skill problem/Solution :  sending job id as query parameter from front end which will bring required skills of that job  from Api.

getting matching skills of candidate from Candidate List (Api) and required Skills from Jobs Api 
then Using Linq displaying top 5 candidates of matching Skills of both (candidate & Jobs) in descending order from most qualified to less qualified.


Project build steps :

This solution contains both angular front end and .NET API,  Api code is inside Controllers and Clients Folders.

Build Angular code by "ng build" command from terminal
then build API code and run the solution from Visual Studio
