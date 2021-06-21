import React, { useState } from 'react';
import Button from './Button'
import Style from './style.sass'
import Modal from './Modal'

function App() {
  const [firstMStatus, setFirstMStatus] = useState(false);
  const [secondMStatus, setSecondMStatus] = useState(false);

  const toggleFirstM = () => setFirstMStatus(v => !v);
  const toggleSecondM = () => setSecondMStatus(v => !v);
  return (
    <div className="App">
      <Button text="Open first Modal" backgroundColor="red" onClick={toggleFirstM} />
      <Button text="Open second Modal" backgroundColor="green" onClick={toggleSecondM} />

      {
        firstMStatus && <Modal
          header="it's first modal"
          closeIcon={true}
          text="Yeah, it is Random text form first Modal, is it good ?"
          close={toggleFirstM}
          actions={
            [
              <Button
                text="Ok"
                backgroundColor="blue"
                onClick={toggleFirstM}
                key="a"
              />,
              <Button
                text="Cancel"
                backgroundColor="red"
                onClick={toggleFirstM}
                key="b"
              />
            ]
          }
        />
      }

      {
        secondMStatus && <Modal
          header="it's second modal"
          closeIcon={true}
          text="Yeah, it is Random text for second Modal, is it good ?"
          close={toggleSecondM}
          actions={
            [
              <Button
                text="Ok"
                backgroundColor="blue"
                onClick={toggleSecondM}
                key="c"
              />,
              <Button
                text="Cancel"
                backgroundColor="red"
                onClick={toggleSecondM}
                key="d"
              />
            ]
          }
        />
      }

 
    </div>
  );
}

export default App;
