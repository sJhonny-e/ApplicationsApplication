(function creditCardsController() {
    'use strict'
    var totalSelectedCredit = 0;    // private instance variable, holds the total credit of selected credit cards

    document.addEventListener('applicantsLoaded', function setApplicantsClickHandlers() {
        initTotalCredit();
        var allApplicants = document.getElementsByClassName('applicant-item');
        for (var i = 0; i < allApplicants.length; i++) {
            allApplicants[i].addEventListener('applicantSelected', getCreditCardsForApplicant);
        }
    });

    var container = document.getElementById('cc-container')
        .getElementsByClassName('cc-row')[0];   // TODO: make this more generic (i.e allow for multiple rows)

    function getCreditCardsForApplicant(e) {
        initTotalCredit();

        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (this.readyState == XMLHttpRequest.DONE) {
                renderCreditCards(JSON.parse(this.responseText));
            }
        }
        var applicantId = e.detail;
        xhr.open('GET', '/api/creditcards/applicant/' + applicantId, true);
        xhr.send(null);
    }

    function renderCreditCards(creditCards) {
        container.innerHTML = '';   // clear previous content
        for (var i = 0; i < creditCards.length; i++) {
            var element = renderCreditCard(creditCards[i]);
            element.onclick = createSelectCreditCardHandler(creditCards[i], element);
            container.appendChild(element);
        }
    }

    function renderCreditCard(creditCard) {
        var template = document.getElementById('templates-container')
               .getElementsByClassName('cc-item')[0]
                .cloneNode(true);
        //init name + description
        template.getElementsByClassName('cc-name')[0].innerHTML = creditCard.name;
        template.getElementsByClassName('cc-desc')[0].innerHTML = creditCard.description;
        //APR
        template.getElementsByClassName('apr')[0].innerHTML = creditCard.apr + '%';
        //offer periods
        template.getElementsByClassName('balance-transfer')[0].innerHTML = creditCard.balanceTransferOfferDurationMonths;
        template.getElementsByClassName('purchase-offer')[0].innerHTML = creditCard.purchaseOfferDurationMonths;
        //available credit
        template.getElementsByClassName('credit')[0].innerHTML = creditCard.creditAvailable;

        return template;
    }

    function createSelectCreditCardHandler(creditCard, element) {
        return function creditCardToggle() {
            var creditToAdd = creditCard.creditAvailable;
            // toggle selection status
            if (element.classList.contains('selected')) {
                element.classList.remove('selected');
                creditToAdd = -creditToAdd;
            }
            else {
                element.classList.add('selected');
            }
            addToTotalCredit(creditToAdd);
        }
    }

    function initTotalCredit() {
        totalSelectedCredit = 0;
        displayTotalCredit();
    }

    function addToTotalCredit(amount) {
        totalSelectedCredit += amount;
        displayTotalCredit();
    }

    function displayTotalCredit() {
        document.getElementById('total-credit').innerHTML = totalSelectedCredit;
    }

})();