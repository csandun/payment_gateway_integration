## Payment Gateway Integration

### Tools
1. https://jsontostring.com/
2. https://json2csharp.com/

### Techologies
1. Payment Gateway API
2. Asp.net core 5
3. React
4. Azure Web app
5. Azure application Insight

### Scripts
#### Filter app insight events
```requests 
| extend requestVal = tostring(todynamic(tostring( customDimensions.RequestBody))["event"])
| where  tostring( customDimensions.RequestBody)  contains "00b30000618d82798c7ed2e6f9488f86"  or tostring( customDimensions.ResponseBody)  contains "00b30000618d82798c7ed2e6f9488f86" 
| project timestamp ,name , requestVal, "" , customDimensions
| order by timestamp
```


