# HTTP Requests Implementation Instructions

## Overview
This instruction file guides AI assistants in implementing HTTP request classes for the Disconance library based on the Discord API documentation found in `modules/discord-api-docs/docs/resources/`.

## Project Structure
- **Request Classes Location**: `src/Disconance.Http.Requests/`
- **Models Location**: `src/Disconance.Models/`
- **API Documentation**: `modules/discord-api-docs/docs/resources/`

## Implementation Pattern

### 1. Analyze Discord API Documentation
When implementing requests for a resource (e.g., Messages, Channels, Guilds):

1. Open the corresponding `.mdx` file in `modules/discord-api-docs/docs/resources/`
2. Search for HTTP endpoint definitions using the format:
   - `<Route method="GET">/path/to/endpoint</Route>`
   - `<Route method="POST">/path/to/endpoint</Route>`
   - `<Route method="PATCH">/path/to/endpoint</Route>`
   - `<Route method="PUT">/path/to/endpoint</Route>`
   - `<Route method="DELETE">/path/to/endpoint</Route>`

3. For each endpoint, identify:
   - HTTP method (GET, POST, PATCH, PUT, DELETE)
   - Path parameters (e.g., `{channel.id}`, `{message.id}`)
   - Query parameters (usually in a table labeled "Query String Params")
   - JSON body parameters (usually in a table labeled "JSON Params" or "JSON/Form Params")
   - Response type (what the endpoint returns)
   - Permissions and limitations mentioned

### 2. Request Class Naming Convention
Follow these patterns:
- **GET single resource**: `Get{Resource}Request` (e.g., `GetChannelMessageRequest`)
- **GET multiple resources**: `Get{Resource}sRequest` or `Get{Context}{Resource}sRequest` (e.g., `GetChannelMessagesRequest`)
- **POST (create)**: `Create{Resource}Request` (e.g., `CreateMessageRequest`)
- **POST (special action)**: `{Action}{Resource}Request` (e.g., `BulkDeleteMessagesRequest`, `CrosspostMessageRequest`)
- **PATCH/PUT**: `Edit{Resource}Request` or `Update{Resource}Request` (e.g., `EditMessageRequest`)
- **DELETE**: `Delete{Resource}Request` (e.g., `DeleteMessageRequest`)

### 3. File Organization
Create a folder for each major resource type:
```
src/Disconance.Http.Requests/
├── Applications/
│   ├── CreateGlobalApplicationCommandRequest.cs
│   ├── GetCurrentApplicationRequest.cs
│   └── ...
├── Messages/
│   ├── CreateMessageRequest.cs
│   ├── GetChannelMessagesRequest.cs
│   └── ...
└── Channels/
    └── ...
```

### 4. Request Class Template

**Use `record` for all request classes** to maintain consistency and leverage value-based equality semantics.

#### For Requests with Path Parameters
```csharp
using Disconance.Models;
using Disconance.Models.{ResourceNamespace};

namespace Disconance.Http.Requests.{ResourceFolder};

/// <summary>
///     {Description from Discord API docs}
///     {Include permission requirements}
///     {Include return value description}
/// </summary>
/// <param name="{ParamName}">The ID of the {resource} to {action}.</param>
/// <param name="{ParamName2}">The ID of the {resource2} to {action}.</param>
public record {RequestName}(Snowflake {ParamName}, Snowflake {ParamName2}) : IRequest<{ResponseType}>
{
    /// <summary>
    ///     {Property description from API docs}
    /// </summary>
    public {Type}? {PropertyName} { get; set; }

    // Add all query parameters (for GET) or body parameters (for POST/PATCH)
    
    public HttpMethod Method => HttpMethod.{Get|Post|Patch|Put|Delete};

    public string Path => $"{resource_path}/{{{ParamName}}}/{nested_path}";
}
```

#### For Requests without Path Parameters
```csharp
using Disconance.Models;
using Disconance.Models.{ResourceNamespace};

namespace Disconance.Http.Requests.{ResourceFolder};

/// <summary>
///     {Description from Discord API docs}
/// </summary>
public record {RequestName} : IRequest<{ResponseType}>
{
    /// <summary>
    ///     {Property description from API docs}
    /// </summary>
    public {Type}? {PropertyName} { get; set; }
    
    public HttpMethod Method => HttpMethod.{Get|Post|Patch|Put|Delete};

    public string Path => "{resource_path}";
}
```

### 5. Key Implementation Rules

#### Response Types
- Single resource → `IRequest<ResourceType>` (e.g., `IRequest<Message>`)
- Multiple resources → `IRequest<List<ResourceType>>` (e.g., `IRequest<List<Message>>`)
- No meaningful response (204) → `IRequest<object>`

#### Property Types
- **Snowflake IDs**: Use `Snowflake` or `Snowflake?` for nullable IDs
- **Arrays**: Use `List<T>` for collections
- **Nullable fields**: Add `?` for optional parameters
- **Required fields**: Use `required` modifier (e.g., `public required string Name { get; init; }`)
- **Enums**: Reference existing enum types from `Disconance.Models`
- **Complex objects**: Reference model classes from `Disconance.Models.{Namespace}`

#### Parameter Handling
- **Path parameters**: Defined as record constructor parameters
- **Query parameters** (GET requests): Defined as properties (automatically serialized)
- **Body parameters** (POST/PATCH/PUT): Defined as properties (automatically serialized)
- **Optional parameters**: Make nullable with `?`

#### HTTP Method Mapping
```csharp
public HttpMethod Method => HttpMethod.Get;     // GET
public HttpMethod Method => HttpMethod.Post;    // POST
public HttpMethod Method => HttpMethod.Patch;   // PATCH
public HttpMethod Method => HttpMethod.Put;     // PUT
public HttpMethod Method => HttpMethod.Delete;  // DELETE
```

#### Path Construction
- Use string interpolation with `$"..."`
- Path parameters from constructor: `$"channels/{ChannelId}/messages"`
- Multiple parameters: `$"channels/{ChannelId}/messages/{MessageId}"`
- Static paths: `"applications/@me"`

### 6. XML Documentation Guidelines

1. **Summary**: Copy the description from Discord API docs
2. **Include**:
   - Return value description (e.g., "Returns a message object")
   - Permission requirements (e.g., "Requires the MANAGE_MESSAGES permission")
   - Limitations (e.g., "Max 100 messages")
   - Event triggers (e.g., "Fires a Message Create Gateway event")
3. **Property documentation**: Copy field descriptions from API docs tables
4. **Constructor parameters**: Describe what each ID represents

### 7. Common Patterns

#### Pagination
```csharp
public Snowflake? Before { get; set; }
public Snowflake? After { get; set; }
public int? Limit { get; set; }
```

#### Optional Content Fields
```csharp
public string? Content { get; set; }
public List<Embed>? Embeds { get; set; }
public List<IComponent>? Components { get; set; }
```

#### Flags and Permissions
```csharp
public MessageFlags? Flags { get; set; }
```

### 8. Workflow for New Resource Implementation

1. **Identify resource**: Choose a resource from `modules/discord-api-docs/docs/resources/`
2. **Scan endpoints**: Search the `.mdx` file for all `<Route>` tags
3. **Create folder**: Make a new folder in `src/Disconance.Http.Requests/` if needed
4. **Implement requests**: Create one file per endpoint, following the template
5. **Verify models exist**: Check that response types exist in `src/Disconance.Models/`
6. **Build project**: Run `dotnet build` to verify no compilation errors
7. **Test coverage**: Ensure all major CRUD operations are covered

### 9. Model Verification
Before implementing a request:
- Verify the response model exists in `src/Disconance.Models/`
- If a required model does not exist, create it in the appropriate folder within `src/Disconance.Models/` following the established patterns. Do not create nested classes within request files.
- Check property names match Discord API field names (snake_case in docs → PascalCase in C#)
- Ensure enums and complex types are available

### 10. Example: Complete Message Resource

From `message.mdx`, implement:
- ✅ `CreateMessageRequest` - POST /channels/{channel.id}/messages
- ✅ `GetChannelMessagesRequest` - GET /channels/{channel.id}/messages
- ✅ `GetChannelMessageRequest` - GET /channels/{channel.id}/messages/{message.id}
- ✅ `EditMessageRequest` - PATCH /channels/{channel.id}/messages/{message.id}
- ✅ `DeleteMessageRequest` - DELETE /channels/{channel.id}/messages/{message.id}
- ✅ `BulkDeleteMessagesRequest` - POST /channels/{channel.id}/messages/bulk-delete

### 11. Priority Order for Implementation
Implement resources in this order:
1. **Messages** ✅ (Core functionality)
2. **Channels** (Channel management)
3. **Guilds** (Server management)
4. **Users** (User information)
5. **Webhooks** (Webhook management)
6. **Interactions** (Application commands/interactions)
7. **Other resources** (As needed)

### 12. Quality Checklist
Before completing implementation:
- [ ] All endpoints from `.mdx` file are implemented
- [ ] XML documentation is complete and accurate
- [ ] Naming follows established conventions
- [ ] Response types are correct
- [ ] Required vs optional parameters are properly marked
- [ ] Project builds without errors
- [ ] Path construction is correct
- [ ] HTTP method matches Discord API docs

## Notes
- The `DefaultRequestHandler` automatically handles query parameter serialization for GET requests
- The handler also serializes body parameters for POST/PATCH/PUT requests
- Path should NOT include the base Discord API URL or version (e.g., use `"channels/{id}"` not `"/api/v10/channels/{id}"`)
- Use existing models from `Disconance.Models` - do not create duplicate types
