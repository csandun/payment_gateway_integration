## Payment Gateway Integration

### tools
https://jsontostring.com/
https://json2csharp.com/


### techologies
1. Payment Gateway API
2. Asp.net core 5
3. React
4. Azure Web app
5. Azure application Insight

### scripts
#### filter app insight events
```requests 
| extend requestVal = tostring(todynamic(tostring( customDimensions.RequestBody))["event"])
| where  tostring( customDimensions.RequestBody)  contains "00b30000618d82798c7ed2e6f9488f86"  or tostring( customDimensions.ResponseBody)  contains "00b30000618d82798c7ed2e6f9488f86" 
| project timestamp ,name , requestVal, "" , customDimensions
| order by timestamp
```


