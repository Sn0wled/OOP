/**
 * Project PaintApplicatioin
 */


#ifndef _PAINTAPP_H
#define _PAINTAPP_H

class PaintApp {
public: 
    
void show();
    
/**
 * @param index
 */
figure* add(int index);
    
/**
 * @param item
 */
void item(figure* item);
    
void PaintApp();
protected: 
    vector<figure*> figures;
};

#endif //_PAINTAPP_H