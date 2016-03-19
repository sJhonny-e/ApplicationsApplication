(function applicantsController() {
    'use strict'
    // first - retrieve all applicants
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == XMLHttpRequest.DONE) {
            renderApplicants(JSON.parse(this.responseText));
        }
    }
    xhr.open('GET', '/api/applicants', true);
    xhr.send(null);

    var container = document.getElementById('applicants-container')
        .getElementsByClassName('applicants-row')[0];
    
    function renderApplicants(applicants) {
        container.innerHTML = '';   // clear previous content
        for (var i = 0; i < applicants.length; i++) {
            var applicant = applicants[i];
            var element = createApplicantElement(applicant);

            createClickEvent(applicant, element);
            element.addEventListener('applicantSelected', toggleSelectedApplicant);
            container.appendChild(element);   // TODO: would be more efficient to render all at once rather than one by one
        }
        var loadedEvent = new Event('applicantsLoaded');
        document.dispatchEvent(loadedEvent);    // notify that applicants were loaded
    }

    function createApplicantElement(applicant) {
        var template = document.getElementById('templates-container')
               .getElementsByClassName('applicant-item')[0]
                .cloneNode(true);

        template.setAttribute('applicant-id', applicant.id);
        var displayName = getDisplayName(applicant);

        // init image
        var image = template.getElementsByTagName('img')[0];
        image.alt = displayName;
        image.title = displayName;
        image.src = applicant.imageUrl;

        // init name
        template.getElementsByClassName('applicant-name')[0].innerHTML = displayName;
        // init DOB
        var dateOfBirth = new Date(applicant.dateOfBirth);
        var dateInAReasonableFormat = dateOfBirth.getDate() + '/' + dateOfBirth.getMonth() + '/' + dateOfBirth.getFullYear();
        template.getElementsByClassName('dob')[0].innerHTML = dateInAReasonableFormat;
        //init employment
        template.getElementsByClassName('employment')[0].innerHTML = getEmploymentStatus(applicant);
        // init income
        template.getElementsByClassName('income')[0].innerHTML = applicant.annualIncome;
        // init address
        template.getElementsByClassName('house-num')[0].innerHTML = applicant.houseNumber;
        template.getElementsByClassName('postcode')[0].innerHTML = applicant.postcode;

        return template;
    }

    function createClickEvent(applicant, element) {
        var applicantClickedEvent = new CustomEvent('applicantSelected', { detail: applicant.id });
        var links = element.getElementsByClassName('applicant-link');
        for (var j = 0; j < links.length; j++) {
            links[j].onclick = function applicantLinkClicked() {
                element.dispatchEvent(applicantClickedEvent);
            }
        }
    }

    function toggleSelectedApplicant(e) {
        // remove the 'selected' indication from the previously selected applicant
        var selected = container.getElementsByClassName('selected')[0];
        if (selected) selected.classList.remove('selected');

        // add the 'selected' indication to the newly selected applicant
        container.querySelector('[applicant-id="' + e.detail + '"]')
            .classList.add('selected');
    }

    var titleDictionary = ['Ms.', 'Mrs.', 'Mz.', 'Mr.', 'Dr.', 'Professor', 'Jhonny'];
    function getDisplayName(applicant) {
        return titleDictionary[applicant.title] + ' ' + applicant.firstName + ' ' + applicant.lastName;
    }

    var employmentDictionary = [
        'Student',
        'Office Pleb',
        'Employed Part-time',
        'On The Dole',
        'Retired'
    ];
    function getEmploymentStatus(applicant) {
        return employmentDictionary[applicant.employmentStatus];
    }

})();