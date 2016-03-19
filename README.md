# ApplicationsApplication
Application for viewing credit card applications
##Installation & Running
* Clone repo
* Install missing packages
* Run from visual studio (or, if you're more adventurous - set up IIS to serve the site and go to /views/index.html)
  
* Note: I tested this on Firefox only.

##About the solution
###Server
A simple WebAPI server with a couple of controllers; nothing there really.  
The logic of which card is being offered to whom is implemented using the `IEligiblityChecker` interface, and its implementing classes;  
Each implementing class can define its own logic as to whether an applicant is eligible (for example - based on employment status, age, income..).  
To determine whether an applicant is eligible for a specific card, all of the card's `EligibilityChecker`s are queried.  
####Points to improve
* Use proper DI mechanism
* Build a better rule engine to allow different 'OR' and 'AND' combinations of `EligibilityChecker`s
* Use [an ORM instead of repositories](https://ayende.com/blog/3955/repository-is-the-new-singleton)
* When scaling, it's of course necessary to separate the different parts (Model, Controllers, DAL..) into different projects
* Better routing definitions

###Client
Just vanilla Javascript (ES5) with twitter bootstrap CSS.  
Since this is a super small-scale app, I didn't see the need to go with a full-blown framework, especially considering the fact it'll probably be a [huge pain to set up](https://medium.com/@ericclemmons/javascript-fatigue-48d4011b6fc4#.s41zb52ed).  
Additionaly, it's been years since I've done vanilla JS, so I thought I'd give it a try :)    
I just added a couple of simple scripts that handle user selections and the correspoding AJAX calls they trigger, and then displaying the information returned.  
