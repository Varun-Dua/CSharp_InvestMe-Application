# InvestMe-Application

InvestMe Application:  
Your client MyMoney Bank Corp is a financial services company that offers various investment products to its customers. One of these is a medium-term investment product called ‘InvestMe’, in which a client invests a principal sum of money and receive returns depending on the amount and duration of the Investment (terms ranging from 1 to 10 years). Your company has been commissioned to create a well-designed application for bank employees to process client transactions for this product. 
 
Basic Flow of Events 
A client on expressing interest in the ‘InvestMe’ product is asked by the employee how much they would like to invest; this figure is inputted into the application and the display button is pressed. The application displays each of the four terms available (1, 3, 5 & 10 years) with the applicable interest rate for each term, and the balance that will have accrued on the investment at the end of each of the terms.  The interest on investments in the ‘InvestMe’ product is compounded monthly, with an interest rate schedule as detailed in table 1 on the next page. 

If the client chooses a term they wish to invest for, the employee selects this option and presses the proceed button. A random six-character transaction number is generated, along with this the employee enters the client’s details (Name, Telephone Number & Email address), after which the confirm button is pressed. The application will then display the full details of the investment, its transaction number and its client’s details, and prompts the employee to gain final confirmation of the investment from the client. If the client wishes to proceed, the transaction is saved persistently to text file by the application, a confirmation message is displayed when this process is complete. 
 
 Additional Required Functionality 
• If the employee or the employee’s manager wishes to see the number of ‘InvestMe’ transactions processed to file, they can click the summary button and a report is displayed giving the full list of transaction numbers, as well as the total amount invested, the total interest accruing on the investments and the average duration (term) of an investment.  
• The application should have functionality that allows a user to search previous transactions by entering a transaction number for a single transaction or client email if searching for multiple transactions by the same client. If the search term is found, the full details of the transaction(s) is displayed. 
 
Design Notes 
• Follow principles of good Ux design. 
• Handle any exceptions that could occur in your project & provide user input validation as needed. 
• Include appropriate ToolTips & Access keys. 
• Arrays or any other type of collection are not permitted for use (processing data) in this assignment. 
• A minimum of three methods are required to be developed with this application, with at least one being a value returning method.  
