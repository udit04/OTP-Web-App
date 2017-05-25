# OTP-web-app-C#
The app lets you send OTP (through SMS) to the contacts list on the mian page.

# Contact List
  The index page has two menu buttons - Contact List & Messages Sent
  
  The data is fetched from a static json file which one can modify accordingly or use a DB.
  
# TWILIO API
  The app uses Twilio SMS sending api to send otp to registered numbers on user's twilio account. This applicaton is made with a trial version (You need to purchase the twilio account if you need to send sms to unverified numbers).
  
  The web app sorts the messages sent, according to latest sent messages (date-time).
  
  It only sends a 6 digit otp.
  
# HOW TO RUN ?

  To run this project, you need to clone the whole repository and open the .sln file with visual studio and HIT run button. (Check your framework config in web.config file ).

  DEMO - http://www.coupontodeals.net/sms.aspx
