import React from 'react';
import PropTypes from "prop-types";
// import modal from './modal.sass'

export const Modal = ({ header, closeIcon, actions, text, close }) => {

    return (
        <div className="layOut">
            <div className="modal">
                <header>
                    {header}
                    {{ closeIcon } && <button onClick={close} className="close-btn">x</button>}
                </header>
                <hr />
                <p className="modal-text">{text}</p>
                {actions}
            </div>
        </div>
    )
}

export default Modal;