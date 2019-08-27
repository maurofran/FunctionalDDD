namespace Iam.Common

type String35 = private String35 of string
type String150 = private String150 of string

module String35 =
    let value (String35 str) = str
    
    let create fieldName str =
        ConstrainedType.createString fieldName String35 35 str

    let createOption fieldName str =
        ConstrainedType.createStringOption fieldName String35 35 str

module String150 =
    let value (String150 str) = str
    
    let create fieldName str =
        ConstrainedType.createString fieldName String150 150 str
    
    let createOption fieldName str =
        ConstrainedType.createStringOption fieldName String150 150 str
