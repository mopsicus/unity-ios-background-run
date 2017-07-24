//
//  Background.mm
//  Background
//
//  Created by Mopsicus on 13.07.17.
//

#import <UIKit/UIKit.h>

@interface Background : NSObject {
    UIBackgroundTaskIdentifier bgTask;
}
@end

@implementation Background

-(void)startTask {
    [self endTask];
    if (bgTask == UIBackgroundTaskInvalid) {
        bgTask = [[UIApplication sharedApplication] beginBackgroundTaskWithExpirationHandler:^{
            [[UIApplication sharedApplication] endBackgroundTask:bgTask];
            bgTask = UIBackgroundTaskInvalid;
        }];
    }
}

-(void)endTask {
    if (bgTask != UIBackgroundTaskInvalid) {
        [[UIApplication sharedApplication] endBackgroundTask:bgTask];
        bgTask = UIBackgroundTaskInvalid;
    }
    [UIApplication sharedApplication].idleTimerDisabled = NO;
}

static Background *bg = NULL;

extern "C" {
    
    void backgroundLaunch () {
        if (bg == NULL)
            bg = [[Background alloc] init];
        [bg startTask];
    }
    
    void backgroundStop () {
        if (bg != NULL)
            [bg endTask];
    }

    
}

@end

