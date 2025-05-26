REM GetAllRss
curl -k -L -X POST "https://localhost:7152/SoapNewsFeedService.asmx" -H "Content-Type: text/xml; charset=utf-8" -H "SOAPAction: \"http://tempuri.org/SoapNewsFeedService/GetAllRss\"" --data @requestAll.xml
REM ById
curl -k -L -X POST "https://localhost:7152/SoapNewsFeedService.asmx" -H "Content-Type: text/xml; charset=utf-8" -H "SOAPAction: \"http://tempuri.org/SoapNewsFeedService/GetById\"" --data @requestId.xml
