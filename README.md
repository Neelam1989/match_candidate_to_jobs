# match_candidate_to_jobs

**JobAdder Coding Challenge**

For this exercise, we’d like you to create a web application that will help a recruiter automatically match candidates to open jobs.

Within your UI, (the form the interface takes is open to your interpretation), for each job, display a candidate that is the most-qualified to fill that job.

**Approach and Description**

This app display all jobs when application loads where Job id is a link, if user click on job id all candidates of matching skills with that job will display.

For matching skill problem/Solution :  sending job id as query parameter from front end than API side based on job id getting required skills List of jobs .

Using Linq getting matching candidates from Candidate List and requiredSkills list of Jobs and displaying top 5 candidates of matching Skills in decending order from most qualified to less qualified.


Project build steps :

This solution contain both angular front end and API, API code is inside Controllers and Clients Folder.

Build Angular code by "ng build" from terminal
than buil API code and run the solution from Visual Studio
