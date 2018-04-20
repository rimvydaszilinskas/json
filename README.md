# JSON library for C#

## How to use
- Add reference in your C# solution
- Include the following line
  ```c#
  using JSON;
  ```
- Initialize a new instance of JSON
  ```c#
  IJSON json = new JSON();
  ```
- Add simple key : value, where value can be int, double or string
  ```c#
  json.add("key", value);
  ```
- It is also possible to nest functions
  ```c#
  json.add("key", value).add("anotherkey", anothervalue);
  ```
- You can also merge two JSON objects together
  ```c#
  IJSON json = new JSON();
  IJSON json1 = new JSON();
  json.add("key", "value");
  json1.add("another_key", "value");
  
  json.merge(json1);
  // this will produce
  // { "key" : "value", "another_key" : "value" } 
  ```
- To get back the JSON string use GetFormatted()
  ```c#
  json.getFormatted();
  ```
- To get back the list of keys in a List<String> format
  ```c#
  json.getKeys();
  ```
- To get back the length
  ```c#
  json.length();
  ```
  
[Personal web](http://rimvydas.site)
