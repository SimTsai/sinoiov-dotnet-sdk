# 智运开放平台 dotnet SDK

## How to use

### Non DI
- app.config or web.config
```xml
<configuration>
  <configSections>
    <section name="sinoiov" type="Sinoiov.OpenApi.ConfigurationSection.SinoiovConfigurationSection, Sinoiov.OpenApi"/>
  </configSections>
  <sinoiov environment="Test" tokenStorageIn="Redis">
    <account
      user=""
      password=""
      clientID=""
      secret="" />
    <redisOptions connectionString="192.168.1.223:6379" />
  </sinoiov>
</configuration>
```

- 使用
```csharp
using var sinoiovService =  SinoiovServiceFactory.CreateSinoiovService();
```

### With DI (IServiceCollection)
- in startup ConfigureServices
```csharp
service.AddSinoiov()
```
- appsettings.{?}.json
```json
{
  "Sinoiov": {
    "Environment": "Test",  // 连接中交兴路的环境 Test OR Production
    "Account": { // 中交兴路提供的账号信息
        "User": "",
        "Password": "",
        "ClientID": "",
        "Secret": ""
    },
    "TokenStorageIn": "Redis", // Token存储位置 Redis OR InMemory
    "InMemoryOptions": { // see also Microsoft.Extensions.Caching.Memory.MemoryCacheOptions
        "ExpirationScanFrequency": "",
        "SizeLimit": "",
        "CompactionPercentage": 
    },
    "RedisOptions": { // see also Microsoft.Extensions.Caching.StackExchangeRedis.RedisCacheOptions
      "Configuration": "192.168.1.223:6379",
      "InstanceName": ""
    }
  }
}
```


### 已实现方法
|接口文档|DI|NonDI|实现版本|
|-|-|-|-|
|5.2. 用户认证和接口安全|-|-|3.2.2-dev.1|
|6.1.4. 多车最新位置查询|`ISinoiovLocationService.VLastLocationMultiV4Async`|`ISinoiovService.SinoiovLocationService`|3.2.2-dev.1|
