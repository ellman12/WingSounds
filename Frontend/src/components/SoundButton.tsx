import {FC} from "react";
import SoundboardSound from "../api/SoundboardSound.ts";
import axiosInstance from "../api/axios.ts";

interface Props {
    sound: SoundboardSound;
}

const SoundButton: FC<Props> = ({sound}) => {
    async function onClick() {
        await sendSound();
    }

    async function sendSound() {
        const idk = await axiosInstance.post("soundboard/send-soundboard-sound", JSON.stringify(sound));
        console.log(idk);
    }

    return (
        <button className="mx-64" onClick={onClick}>
            {sound.name}
        </button>
    );
};

export default SoundButton;
