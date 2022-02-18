#pragma once

// we are still allowing to build with older sdk and run on simulator without metal support (pre MacOS 10.15)
// it is expected to substitute Metal.h so we assume this is used only with objc

#ifdef __cplusplus
extern "C" typedef MTLDeviceRef (*MTLCreateSystemDefaultDeviceFunc)();
#else
typedef MTLDeviceRef (*MTLCreateSystemDefaultDeviceFunc)();
#endif


#if UNITY_CAN_USE_METAL

    #import <Metal/Metal.h>
    #import <QuartzCore/CAMetalLayer.h>

#else

// even if we cant use metal, we should be able to build it still: we need protocol declarations

@interface CAMetalLayer : CALayer
@property (readwrite) BOOL framebufferOnly;
@property (readwrite) CGSize drawableSize;
@property BOOL presentsWithTransaction;
@property (readwrite, retain) id<MTLDevice> device;
@property (readwrite) MTLPixelFormat pixelFormat;
@property (readonly) id<MTLTexture> texture;

- (id<CAMetalDrawable>)newDrawable;
- (id<CAMetalDrawable>)nextDrawable;
@end

@protocol MTLDrawable
@end
@protocol CAMetalDrawable<MTLDrawable>
@property (readonly) id<MTLTexture> texture;
@end

@protocol MTLDevice
- (id<MTLCommandQueue>)newCommandQueue;
- (id<MTLCommandQueue>)newCommandQueueWithMaxCommandBufferCount:(NSUInteger)maxCommandBufferCount;
- (BOOL)supportsTextureSampleCount:(NSUInteger)sampleCount;
@end

@protocol MTLCommandBuffer
- (void)presentDrawable:(id<MTLDrawable>)drawable;
@end

#endif
