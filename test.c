#include <stdio.h>

void swap(int* a,int* b)
{
    int temp;
    temp = *a;
    *a = *b;
    *b = *a;
}

void nextPermutation(int* nums, int numsSize){
    int i = 0;
    int j = 0;
    
    if(nums == NULL||numsSize < 2)
        return;
    
    for (i=numsSize-2;i>=0;i--)
    {
        if(nums[i]>=nums[i+1])
            continue;
        
        for(j=numsSize-1;j>=i+1;j--)
            if(nums[j]>nums[i])
            {
                swap(&nums[j],&nums[i]);
                break;
            }
        
        for(j=i+1;j<(i+numsSize)/2;j++)
            swap(&nums[j],&nums[numsSize-1-j]);
        
        break;
    }
}

void main()
{
 	int a[] = {1,2,3};
        nextPermutation(a,3);
}
