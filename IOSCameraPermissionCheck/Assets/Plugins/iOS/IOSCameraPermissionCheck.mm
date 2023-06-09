extern "C" {
    // Helper method to create C string copy
    char* MakeStringCopy (NSString* nsstring)
    {
        if (nsstring == NULL) {
            return NULL;
        }
        // convert from NSString to char with utf8 encoding
        const char* string = [nsstring cStringUsingEncoding:NSUTF8StringEncoding];
        if (string == NULL) {
            return NULL;
        }

        // create char copy with malloc and strcpy
        char* res = (char*)malloc(strlen(string) + 1);
        strcpy(res, string);
        return res;
    }

    const char* CheckCameraPermission () {
        NSString *mediaType = AVMediaTypeVideo;
        AVAuthorizationStatus authStatus = [AVCaptureDevice authorizationStatusForMediaType:mediaType];

        if(authStatus == AVAuthorizationStatusAuthorized) {
            return "Authorized";
        // do your logic
        } else if(authStatus == AVAuthorizationStatusDenied){
            return "Denied";
        // denied
        } else if(authStatus == AVAuthorizationStatusRestricted){
            return "Restricted";
        // restricted, normally won't happen
        } else if(authStatus == AVAuthorizationStatusNotDetermined){
        // not determined?!
        [AVCaptureDevice requestAccessForMediaType:mediaType completionHandler:^(BOOL granted) {
            if(granted){
                return "Granted access to";
            } else {
                return "Not granted access to";
            }
        }];
        } else {
              return "impossible, unknown authorization status";
        }
    }
}